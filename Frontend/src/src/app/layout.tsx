import 'bootstrap/dist/css/bootstrap.min.css';
import './globals.css';
import { Inter } from 'next/font/google';
import TopMenu from './ui/TopMenu';


const inter = Inter({ subsets: ['latin'] });

export const metadata: Metadata = {
  title: 'Outdoor Marketplace',
  description: 'An outdoor marketplace',
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body className={inter.className}>
        <TopMenu />
        {children}
      </body>
    </html>
  );
}

